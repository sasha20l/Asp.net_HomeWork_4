using System;
using System.Collections.Generic;
using System.Data.SQLite;
using AutoMapper;
using MetricsAgent.DAL.interfaces;
using MetricsAgent.DAL.Request;
using MetricsAgent.DAL.Responses;
using MetricsAgent.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddController : ControllerBase
    {
        private IHddMetricsRepository repository;
        private readonly ILogger<HddController> _logger;
        private readonly IMapper mapper;

        public HddController(IHddMetricsRepository repository, ILogger<HddController> logger, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в HddMetricsController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            repository.Create(new HddMetric
            {
                Time = request.Time,
                Value = request.Value
            });
            return Ok();
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            IList<HddMetric> metrics = repository.GetAll();
            var response = new AllHddMetricsResponse()
            {
                Metrics = new List<HddMetricDto>()
            };
            foreach (var metric in metrics)
            {
                response.Metrics.Add(mapper.Map<HddMetricDto>(metric));
            }
            return Ok(response);
        }


        [HttpGet("sql-read-write-test")]
        public IActionResult TryToInsertAndRead()
        {
            // Создаем строку подключения в виде базы данных в оперативной памяти
            string connectionString = "Data Source=:memory:";
            // создаем соединение с базой данных
            using (var connection = new SQLiteConnection(connectionString))
            {
                // открываем соединение
                connection.Open();
                // создаем объект через который будут выполняться команды к базе данных
                using (var command = new SQLiteCommand(connection))
                {
                    // задаем новый текст команды для выполнения
                    // удаляем таблицу с метриками если она существует в базе данных
                    command.CommandText = "DROP TABLE IF EXISTS hddmetrics";
                    // отправляем запрос в базу данных
                    command.ExecuteNonQuery();
                    // создаем таблицу с метриками
                    command.CommandText = @"CREATE TABLE hddmetrics(id INTEGER PRIMARY KEY, value INT, time INT)";
                    command.ExecuteNonQuery();
                    // создаем запрос на вставку данных
                    command.CommandText = "INSERT INTO hddmetrics(value, time) VALUES(10, 1)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO hddmetrics(value, time) VALUES(50, 2)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO hddmetrics(value, time) VALUES(75, 4)";
                    command.ExecuteNonQuery();
                    command.CommandText = "INSERT INTO hddmetrics(value, time) VALUES(90, 5)";
                    command.ExecuteNonQuery();
                    // создаем строку для выборки данных из базы
                    // LIMIT 3 обозначает, что мы достанем только 3 записи
                    string readQuery = "SELECT * FROM hddmetrics LIMIT 3";
                    // создаем массив, в который запишем объекты с данными из базы данных
                    var returnArray = new HddMetricDto[3];
                    // изменяем текст команды на наш запрос чтения
                    command.CommandText = readQuery;
                    // создаем читалку из базы данных
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // счетчик для того, чтобы записать объект в правильное место в массиве
                        var counter = 0;
                        // цикл будет выполняться до тех пор, пока есть что читать из базы данных
                        while (reader.Read())
                        {
                            // создаем объект и записываем его в массив
                            returnArray[counter] = new HddMetricDto
                            {
                                Id = reader.GetInt32(0), // читаем данные полученные из базы данных
                                Value = reader.GetInt32(0), // преобразуя к целочисленному типу
                                Time = TimeSpan.Parse(reader.GetInt32(0).ToString())
                            };
                            // увеличиваем значение счетчика
                            counter++;
                        }
                    }
                    // оборачиваем массив с данными в объект ответа и возвращаем пользователю
                    return Ok(returnArray);
                }
            }
        }

        [HttpGet("sql-test")]
        public IActionResult TryToSqlLite()
        {
            string cs = "Data Source=:memory:";
            string stm = "SELECT SQLITE_VERSION()";
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                using var cmd = new SQLiteCommand(stm, con);
                string version = cmd.ExecuteScalar().ToString();
                return Ok(version);
            }
        }
        [HttpGet("api/metrics/hdd/left")]
        public IActionResult GetMetricsHdd([FromRoute] TimeSpan fromTime,
        [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
