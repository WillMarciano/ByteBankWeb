using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome
    {
        public IWebDriver driver { get; private set; }
        public NavegandoNaPaginaHome() =>
            //Arrange
            driver = new ChromeDriver();

        [Fact]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {            
            //Act
            driver.Navigate().GoToUrl("https://localhost:7155");

            //Assert
            Assert.Contains("WebApp", driver.Title);
        }

        [Fact]
        public void CarregaPaginaHomeVerificaExistenciaLinkLoginEHomet()
        {
            //Act
            driver.Navigate().GoToUrl("https://localhost:7155");

            //Assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);
        }

        [Fact]
        public void LogandoNoSistema()
        {
            driver.Navigate().GoToUrl("https://localhost:7155/");
            driver.Manage().Window.Size = new System.Drawing.Size(1280, 672);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("admin@email.com");
            driver.FindElement(By.Id("Senha")).Click();
            driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            driver.FindElement(By.Id("btn-logar")).Click();
        }

        [Fact]
        public void ValidaLinkDeLoginNaHome()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost:7155/");
            var linkLogin = driver.FindElement(By.LinkText("Login"));

            //Act
            linkLogin.Click();

            //Assert
            Assert.Contains("img", driver.PageSource);
        }

        [Fact]
        public void AcessarPaginaSemEstarLogado()
        {
            //Act
            driver.Navigate().GoToUrl("https://localhost:7155/Agencia/Index");

            //Assert
            Assert.Contains("https://localhost:7155/Agencia/Index", driver.PageSource);
            Assert.Contains("401", driver.PageSource);
        }
    }
}
