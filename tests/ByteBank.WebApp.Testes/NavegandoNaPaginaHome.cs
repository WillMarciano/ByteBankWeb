using ByteBank.Dominio.Testes.Utils;
using ByteBank.WebApp.Testes.Utilitarios;
using OpenQA.Selenium;
using Xunit;

namespace ByteBank.WebApp.Testes
{
    [TestCaseOrderer("XUnit.Project.Orderers.PriorityOrderer", "XUnit.Project")]
    public class NavegandoNaPaginaHome : IClassFixture<Gerenciador>
    {
        public IWebDriver Driver { get; private set; }
        public NavegandoNaPaginaHome(Gerenciador gerenciador)
        {
            //Arrange
            Driver = gerenciador.Driver;
        }

  
        [Fact, TestPriority(1)]
        public void AcessarPaginaSemEstarLogado()
        {
            //Act
            Driver.Navigate().GoToUrl("https://localhost:7155/Agencia/Index");

            //Assert
            Assert.Contains("401", Driver.PageSource);
        }

        [Fact, TestPriority(2)]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {
            //Act
            Driver.Navigate().GoToUrl("https://localhost:7155");

            //Assert
            Assert.Contains("WebApp", Driver.Title);
        }

        [Fact, TestPriority(3)]
        public void CarregaPaginaHomeVerificaExistenciaLinkLoginEHomet()
        {
            //Act
            Driver.Navigate().GoToUrl("https://localhost:7155");

            //Assert
            Assert.Contains("Login", Driver.PageSource);
            Assert.Contains("Home", Driver.PageSource);
        }

        [Fact, TestPriority(4)]
        public void LogandoNoSistema()
        {
            Driver.Navigate().GoToUrl("https://localhost:7155/");
            Driver.Manage().Window.Size = new System.Drawing.Size(1280, 672);
            Driver.FindElement(By.LinkText("Login")).Click();
            Driver.FindElement(By.Id("Email")).Click();
            Driver.FindElement(By.Id("Email")).SendKeys("admin@email.com");
            Driver.FindElement(By.Id("Senha")).Click();
            Driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            Driver.FindElement(By.Id("btn-logar")).Click();
        }

        [Fact, TestPriority(5)]
        public void ValidaLinkDeLoginNaHome()
        {
            //Arrange
            Driver.Navigate().GoToUrl("https://localhost:7155/");
            var linkLogin = Driver.FindElement(By.LinkText("Login"));

            //Act
            linkLogin.Click();

            //Assert
            Assert.Contains("img", Driver.PageSource);
        }



    }
}
