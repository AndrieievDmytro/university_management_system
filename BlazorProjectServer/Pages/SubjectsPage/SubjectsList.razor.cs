using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using BlazorProjectServer.Models;
using BlazorProjectServer.Services;

namespace BlazorProjectServer.Pages.SubjectsPage
{
    public partial class SubjectsList
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IDatabaseService Service { get; set; }
        [Parameter] public int CourseId { get; set; }
        [Parameter] public string CourseTag { get; set; }
        
        public List<Subject> Subjects { get; set; }
        public Course Course { get; set; }
        

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            Subjects = await Service.GetRelatedSubjects(CourseId);
            Course  = await Service.GetCourse(CourseId);
        }


        public void OnAttributeClick(Func<Subject, Object> func)
        {
            Subjects = Subjects.OrderBy(func).ToList();
        }

        public string GetCourseTag()
        {
            CourseTag = Course.CourseTag;
            return CourseTag;
        }

        public void OnSubjectRawClick(int id)
        {
            NavigationManager.NavigateTo($"/courses/subjects/assignments/{id}");
        }
    }
}
