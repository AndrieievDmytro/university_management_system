using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using BlazorProjectServer.Models;
using BlazorProjectServer.Services;

namespace BlazorProjectServer.Pages.AssignmentsPage
{
    public partial class AssignmentsView
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IDatabaseService Service { get; set; }
        [Parameter] public int AssignmentId { get; set; }

        public Assignments Assignments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            Assignments = await Service.GetAssignment(AssignmentId);
        }

        public void Return()
        {
            NavigationManager.NavigateTo("/courses/subjects/assignments/assignment");
        }
    }
}
