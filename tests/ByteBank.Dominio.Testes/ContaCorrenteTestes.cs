﻿using ByteBank.Dominio.Entidades;
using System;
using Xunit;

namespace ByteBank.Dominio.Testes
{
    public class ContaCorrenteTestes
    {
        [Fact]
        public void CriarContaCorrenteValida()
        {
            //Arrange
            float saldo = 50;            
            Guid identificador = Guid.NewGuid();          
            int id = 1;
            var cliente = new Cliente();
            var agencia = new Agencia();

            //Act
            var contacorrente = new ContaCorrente()
            {
                Saldo = saldo,
                Id = id,
                Identificador = identificador,
                Cliente = cliente,
                Agencia = agencia
            };

            //Assert
            Assert.Equal((saldo), contacorrente.Saldo);
            Assert.Equal(id, contacorrente.Id);
            Assert.Equal(identificador, contacorrente.Identificador);
            Assert.NotNull(contacorrente.Agencia);
            Assert.NotNull(contacorrente.Cliente);

        }

        [Fact]
        public void TestaExceptionValorDeSaldoMenorIgualAzero()
        {
            //Arrange        
            int numeroInvalido = -1230;
            //Act
            //Assert
            Assert.Throws<Exception>(
                () => new ContaCorrente().Saldo = numeroInvalido
             );
        }
    }
}
