using SharedTemplate.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTemplate.Repository.Contracts
{
    /// <summary>
    /// Contract for Test repository
    /// </summary>
    public interface ITestRepository
    {
        void Create(Test test);
        void Delete(int id);
        void Update(Test test);
        Test Get(int id);
        IEnumerable<Test> GetAll();
    }
}
