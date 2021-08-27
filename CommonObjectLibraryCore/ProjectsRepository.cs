using System;
using CommonObjectLibraryCore;

namespace Repositories
{
    public class ProjectsRepository
    {
        private ProjectContext _context;

        public  ProjectsRepository()
        {
            _context = new ProjectContext();
        } 

        public ProjectContext ProjectContext{get => _context;}
        public string TestProperty {get =>  "Test";}
    }
}