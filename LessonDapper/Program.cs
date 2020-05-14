using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using LessonDapper.Model;
using LessonDapper.Repositories.CompanyRepositories;
using LessonDapper.Repositories.ModelsRepositories;

namespace LessonDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var compRep = new CompanyRepository();
            var modelRep = new ModelsRepository();
            var id = compRep.AddOne(new Company() { CompanyName = "Yii" });

            var resultAddMany = compRep.AddMany
                (
                    new Company() { CompanyName = "Yii1" },
                    new Company() { CompanyName = "Yii2" },
                    new Company() { CompanyName = "Yii3" },
                    new Company() { CompanyName = "Yii4" }
                );

            var compList = compRep.GetAll();
            var modelList = modelRep.GetAll();
        }
    }
}
