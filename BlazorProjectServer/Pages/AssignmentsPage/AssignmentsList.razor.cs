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
    public partial class AssignmentsList
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IDatabaseService Service { get; set; }
        [Parameter] public int SubjectId { get; set; }

        public List<Assignments> Assignments { get; set; }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            Assignments = await Service.GetRelatedAssignments(SubjectId);
        }

        

        public void OnAttributeClick(Func<Assignments, Object> func)
        {
            Assignments = Assignments.OrderBy(func).ToList();
        }

        public void OnSubjectRawClick(int id)
        {
            NavigationManager.NavigateTo($"courses/subjects/assignments/assignment/{id}");
        }
    }
}
