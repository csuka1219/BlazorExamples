using BlazorEFCoreClean.Application.DTOs;
using BlazorEFCoreClean.Application.Features.Products.Commands;
using BlazorEFCoreClean.Application.Features.Products.Queries;
using BlazorEFCoreClean.WebUI.Server.Components.Component;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorEFCoreClean.WebUI.Server.Components.Pages
{
    public partial class ProductPage
    {
        [Inject]
        public IDialogService DialogService { get; set; } = default!;
        [Inject]
        public ISnackbar SnackbarService { get; set; } = default!;

        private List<ProductDto> _products = new List<ProductDto>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var ProductQuery = new GetAllProductsQuery();
            _products = await Mediator.Send(ProductQuery);
        }

        private async void CreateProduct()
        {
            ProductDto NewProduct = new ProductDto();
            var parameters = new DialogParameters<AddNewProductDialog> { { x => x.productDto, NewProduct } };

            IDialogReference dialog = await DialogService.ShowAsync<AddNewProductDialog>("Add Product", parameters);
            DialogResult? result = await dialog.Result;

            if (result.Canceled)
                return;
            var command = new CreateProductCommand { Product = NewProduct };
            var res = await Mediator.Send(command);
            if (res > 0)
            {
                SnackbarService.Add("Product Added", Severity.Success);
                _products.Add(NewProduct);
            }
        }

        private async void DeleteProduct(int Id)
        {
            var command = new DeleteProductCommand(Id);
            await Mediator.Send(command);
            SnackbarService.Add("Product Deleted", Severity.Success);
            _products.Remove(_products.First(p=>p.Id == Id));
            StateHasChanged();
        }
    }
}
