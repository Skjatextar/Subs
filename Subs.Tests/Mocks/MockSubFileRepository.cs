using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subs.Models.Repository;
using Subs.Models.Interface;
using Subs.Models.Entity;

namespace Subs.Tests.Mocks
{
    public class MockSubFileRepository : ISubFileRepository
    {
        private readonly List<SubFile> _subfiles;
        public MockSubFileRepository(List<SubFile> subfiles)
        {
            _subfiles = subfiles;
        } 
        public IQueryable<SubFile> GetSubfiles()
        {
            return _subfiles.AsQueryable();
        }
    }
}
