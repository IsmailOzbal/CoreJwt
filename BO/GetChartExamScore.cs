﻿using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetChartExamScore : IExamScore
    {
        private IUnitOfWork uow;
        private IGenericRepository<Exam> _examRepo;
        public GetChartExamScore(IUnitOfWork _uow)
        {
            uow = _uow;
            _examRepo = uow.GetRepository<Exam>();
        }
        public Chart GetExamScore()
        {

            Chart chart = new Chart();

            try
            {
                var data = (from a in _examRepo.GetAll()
                            group a by a.Score into ab
                            select new
                            {
                                name = ab.Key.ToString(),
                                count = ab.Count()

                            }).ToList();

                string[] list = data.Select(a => a.name).ToArray();
                int[] arrayData = data.Select(a => a.count).ToArray();
                string series = "Exam Result";

                chart.data = arrayData;
                chart.Labels = list;
                chart.series = series;
            }
            catch
            {
                chart.series = "Exam Result";
                return chart;
            }

           
            return chart;

        }
    }
}