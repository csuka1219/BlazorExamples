using BlazorEFCoreClean.Application.DTOs;
using BlazorEFCoreClean.Application.Features.Orders.Commands;
using BlazorEFCoreClean.Application.Features.Orders.Queries;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorEFCoreClean.WebUI.Server.Components.Pages
{
    public partial class OrderPage
    {
        [Inject]
        public IDialogService DialogService { get; set; } = default!;
        [Inject]
        public ISnackbar SnackbarService { get; set; } = default!;

        private List<OrderDto> _orders = new List<OrderDto>();

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var OrderQuery = new GetAllOrdersQuery();
            _orders = await Mediator.Send(OrderQuery);
        }

        private async void DeleteOrder(int Id)
        {
            var command = new DeleteOrderCommand(Id);
            await Mediator.Send(command);
            SnackbarService.Add("Order Deleted", Severity.Success);
            _orders.Remove(_orders.First(p => p.Id == Id));
            StateHasChanged();
        }

        private string GetProductsName(ICollection<ProductDto> products)
        {
            return String.Join(',', products.Select(p => p.Name));
        }
    }
}
