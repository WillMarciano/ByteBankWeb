using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using Xunit;

namespace ByteBank.WebApp.Testes
{
    public class AposRealizarLogin
    {
        public IWebDriver driver { get; private set; }
        public AposRealizarLogin() =>
            //Arrange
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

        [Fact]
        public void AposRealizarLoginVerificarSeExisteOpcaoAgenciaMenu()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost:7155/UsuarioApps/Login");

            var email = driver.FindElement(By.Id("Email"));
            var senha = driver.FindElement(By.Id("Senha"));
            var btnLogar = driver.FindElement(By.Id("btn-logar"));

            email.SendKeys("admin@email.com");
            senha.SendKeys("senha01");

            //Act
            btnLogar.Click();

            //Assert
            Assert.Contains("Agência", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost:7155/UsuarioApps/Login");

            var email = driver.FindElement(By.Id("Email"));
            var senha = driver.FindElement(By.Id("Senha"));
            var btnLogar = driver.FindElement(By.Id("btn-logar"));

            //Act
            btnLogar.Click();

            //Assert
            Assert.Contains("The Email field is required.", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost:7155/UsuarioApps/Login");

            var email = driver.FindElement(By.Id("Email"));
            var senha = driver.FindElement(By.Id("Senha"));
            var btnLogar = driver.FindElement(By.Id("btn-logar"));

            email.SendKeys("admin@email.com");
            senha.SendKeys("senha");

            //Act
            btnLogar.Click();

            //Assert
            Assert.Contains("Login", driver.PageSource);
        }

        [Fact]
        public void realizarLoginAcessaMenuECadastraCliente()
        {
            //Arrange
            driver.Navigate().GoToUrl("https://localhost:7155/UsuarioApps/Login");

            var email = driver.FindElement(By.Id("Email"));
            var senha = driver.FindElement(By.Id("Senha"));

            email.SendKeys("admin@email.com");
            senha.SendKeys("senha01");

            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.LinkText("Cliente")).Click();
            driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            driver.FindElement(By.LinkText("Cliente")).Click();

        }
    }
}
