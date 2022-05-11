using ByteBank.WebApp.Testes.PageObjects;
using ByteBank.WebApp.Testes.Utilitarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace ByteBank.WebApp.Testes
{
    public class AposRealizarLogin : IClassFixture<Gerenciador>
    {
        public IWebDriver Driver { get; private set; }

        private readonly ITestOutputHelper SaidaConsoleTeste;
        public AposRealizarLogin(Gerenciador gerenciador,ITestOutputHelper _saidaConsoleTeste)
        {
            //Arrange
            Driver = gerenciador.Driver;
            SaidaConsoleTeste = _saidaConsoleTeste;
        }


        [Fact]
        public void AposRealizarLoginVerificarSeExisteOpcaoAgenciaMenu()
        {
            //Arrange
            var loginPO = new LoginPO(Driver);
            loginPO.Navegar("https://localhost:7155/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("admin@email.com", "senha01");
            loginPO.Logar();

            //Assert
            Assert.Contains("Agência", Driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            //Arrange
            var loginPO = new LoginPO(Driver);
            loginPO.Navegar("https://localhost:7155/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("", "");
            loginPO.Logar();

            //Assert
            Assert.Contains("The Email field is required.", Driver.PageSource);
            Assert.Contains("The Senha field is required.", Driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            //Arrange
            var loginPO = new LoginPO(Driver);
            loginPO.Navegar("https://localhost:7155/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("admin@email.com", "senha");
            loginPO.Logar();

            //Assert
            Assert.Contains("Login", Driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaMenuECadastraCliente()
        {
            //Arrange
            var loginPO = new LoginPO(Driver);
            loginPO.Navegar("https://localhost:7155/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("admin@email.com", "senha01");
            loginPO.Logar();

            Driver.FindElement(By.LinkText("Cliente")).Click();
            Driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            Driver.FindElement(By.Id("CPF")).Click();
            Driver.FindElement(By.Id("CPF")).SendKeys("69981034096");
            Driver.FindElement(By.Id("Nome")).Click();
            Driver.FindElement(By.Id("Nome")).SendKeys("Tobey Garfield");
            Driver.FindElement(By.CssSelector(".form-group:nth-child(3)")).Click();
            Driver.FindElement(By.Id("Profissao")).Click();
            Driver.FindElement(By.Id("Profissao")).SendKeys("Cientista");

            //Act
            Driver.FindElement(By.CssSelector(".btn-outline-primary")).Click();
            Driver.FindElement(By.LinkText("Home")).Click();

            //Assert
            Assert.Contains("Logout", Driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaListagemContas()
        {
            //Arrange
            var loginPO = new LoginPO(Driver);
            loginPO.Navegar("https://localhost:7155/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("admin@email.com", "senha01");
            loginPO.Logar();

            //Conta Corrente
            Driver.FindElement(By.Id("contacorrente")).Click();

            IReadOnlyCollection<IWebElement> elements =
                Driver.FindElements(By.TagName("a"));

            //foreach (var e in elements)
            //{
            //    SaidaConsoleTeste.WriteLine(e.Text);
            //}

            //Assert
            //Assert.True(elements.Count == 12);

            var elemento = (from webElemento in elements
                            where webElemento.Text.Contains("Detalhes")
                            select webElemento).First();
            //Act
            elemento.Click();

            //Assert
            Assert.Contains("Voltar", Driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaListagemContasUsandoHomePO()
        {
            //Arrange
            var loginPO = new LoginPO(Driver);
            loginPO.Navegar("https://localhost:7155/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("admin@email.com", "senha01");
            loginPO.Logar();

            var homePO = new HomePO(Driver);
            homePO.LinkContaCorrenteClick();


            //Assert
            Assert.Contains("Adicionar Conta-Corrente", Driver.PageSource);
        }
    }
}
