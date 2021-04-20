using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;


namespace MetricsAgentTest
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuController controller;
        private Mock<ICpuMetricsRepository> mock;

        private ILogger<CpuController> logger;

        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<ICpuMetricsRepository>();
            controller = new CpuController(mock.Object, logger);
        }
        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository =>
            repository.Create(It.IsAny<CpuMetric>())).Verifiable();
            // выполняем действие на контроллере
            var result = controller.Create(new
            MetricsAgent.Request.CpuMetricCreateRequest
            {
                Time = TimeSpan.FromSeconds(1),
                Value
            = 50
            });
            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типомобъекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()),
            Times.AtMostOnce());
        }
    }
}
