using Asp.net_2;
using Asp.net_2.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Nest;
using System;
using Xunit;

namespace MetricsManagerTest
{
    public class UnitTest1
    {
        public class CpuControllerUnitTests
        {
            private CpuMetricsController controller;
            private Mock<ICpuMetricsRepository> mock;

            private ILogger<CpuMetricsController> logger;

            public CpuControllerUnitTests()
            {
                mock = new Mock<ICpuMetricsRepository>();
                controller = new CpuMetricsController(mock.Object, logger);
            }
            [Fact]
            public void Create_ShouldCall_Create_From_Repository()
            {
                // устанавливаем параметр заглушки
                // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
                mock.Setup(repository =>
                repository.Create(It.IsAny<CpuMetrics>())).Verifiable();
                // выполняем действие на контроллере
                var result = controller.Create(new
                Metrics.Requests.CpuMetricCreateRequest
                {
                    Time = TimeSpan.FromSeconds(1),
                    Value = 50
                });
                // проверяем заглушку на то, что пока работал контроллер
                // действительно вызвался метод Create репозитория с нужным типомобъекта в параметре
                mock.Verify(repository => repository.Create(It.IsAny<CpuMetrics>()),
                Times.AtMostOnce());
            }
        }

    }
}
