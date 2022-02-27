using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Data.Entities;

namespace TodoListApi.Data
{
    [TestClass]
    class MockData
    {

        public IEnumerable<TodoItem> TodoList()
        {
            var toDoList = new List<TodoItem>
            {
                new TodoItem {Id =1, Description="Understand the Todlist project user stories", IsCompleted=true},
                new TodoItem {Id =1, Description="Complete high level design document", IsCompleted=true},
                new TodoItem {Id =1, Description="Create project template for API", IsCompleted=true},
                new TodoItem {Id =1, Description="Create project template for Unit testing", IsCompleted=true},
                new TodoItem {Id =1, Description="Commit the changes into github", IsCompleted=true},
                new TodoItem {Id =1, Description="Use Nuget packages - Automapper, swagger, EF-Inmemory", IsCompleted=true},
                new TodoItem {Id =1, Description="Implement User stories", IsCompleted=true},
                new TodoItem {Id =1, Description="Is complete all the userstories ", IsCompleted=false},
                new TodoItem {Id =1, Description="Integrated API with React 100%", IsCompleted=false},
            };

            return toDoList;
        }        

    }
}
