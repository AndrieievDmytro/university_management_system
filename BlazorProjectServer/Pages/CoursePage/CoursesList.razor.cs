using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using BlazorProjectServer.Models;
using BlazorProjectServer.Services;

namespace BlazorProjectServer.Pages.CoursePage
{
    public partial class CoursesList
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IDatabaseService Service { get; set; }

        public List<Course> Courses { get; set; }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            Courses = await Service.GetCourses();
        }

        public void OnAttributeClick(Func<Course, Object> func)
        {
            Courses = Courses.OrderBy(func).ToList();
        }

        public void OnCourseRawClick(int id)
        {
            NavigationManager.NavigateTo($"courses/subjects/{id}");
        }
    }
}
