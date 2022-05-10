using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;

namespace ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome
    {
        [Fact]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            //Act
            driver.Navigate().GoToUrl("https://localhost:7155");

            //Assert
            Assert.Contains("WebApp", driver.Title);
        }

        [Fact]
        public void CarregaPaginaHomeVerificaExistenciaLinkLoginEHomet()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            //Act
            driver.Navigate().GoToUrl("https://localhost:7155");

            //Assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);
        }
    }
}
