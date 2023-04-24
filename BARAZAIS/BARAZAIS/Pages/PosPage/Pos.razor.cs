
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace LOGIC.Pages.PosPage;

public partial class Pos
{
    [Parameter]
    public int GetPendingBillId { get; set; } = 0;

    private bool ToCounter = true;
    private bool ToBillOnHold = false;
    private bool ToDraw = false;
    private bool ToListItems = false;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        SwitchToCounterSummary();
    }

    private void SwitchToCounterSummary()
    {
        ToCounter = true;
        ToBillOnHold = false;
        ToDraw = false;
        ToListItems = false;
    }

    private void SwitchToBillOnHoldsSummary()
    {
        ToCounter = false;
        ToBillOnHold = true;
        ToDraw = false;
        ToListItems = false;
    }

    private void SwitchToDrawSummary()
    {
        ToCounter = false;
        ToBillOnHold = false;
        ToDraw = true;
        ToListItems = false;
    }

    private void SwitchToListAllItems()
    {
        ToCounter = false;
        ToBillOnHold = false;
        ToDraw = false;
        ToListItems = true;
    }
}