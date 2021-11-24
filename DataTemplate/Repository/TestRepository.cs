using DataTemplate.Repository.Contracts;
using SharedTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTemplate.Repository
{
    public class TestRepository : ITestRepository
    {
        public void Create(Test test)
        {
            try
            {
                string command = "InsertTest";
                
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Test Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Test> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Test test)
        {
            throw new NotImplementedException();
        }
    }
}
