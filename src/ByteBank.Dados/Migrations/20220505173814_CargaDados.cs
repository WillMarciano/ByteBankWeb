using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ByteBank.Dados.Migrations
{
    public partial class CargaDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO agencia (Numero, Nome, Endereco, Identificador) VALUES (123,'Agencia Central','Rua: Pedro Alvares Cabral,63','1447c0e7-c328-47e0-a39f-116e5ab597b3')");
            migrationBuilder.Sql("INSERT INTO agencia (Numero, Nome, Endereco, Identificador) VALUES (321, 'Agencia Flores', 'Rua: Odete Roitman, 84', 'a05e08ca-e501-4719-87c4-a7f95c7f8f15')");

            migrationBuilder.Sql("INSERT INTO cliente (Identificador, Cpf, Nome, Profissao)VALUES ('531e5270-8a80-4a2c-8b20-f10182f728fc','30752204009','André Silva','Developer')");
            migrationBuilder.Sql("INSERT INTO cliente (Identificador, Cpf, Nome, Profissao)VALUES ('20cd1c01-5fbf-40b7-b41b-0341bd38fc32','51071126091','João Pedro','Developer')");
            migrationBuilder.Sql("INSERT INTO cliente (Identificador, Cpf, Nome, Profissao)VALUES ('20cd1c01-5fbf-40b7-b41b-0341bd38fc32','22418225070','José Neves','Atleta De Poker')");

            migrationBuilder.Sql("INSERT INTO conta_corrente (Numero,ClienteId,Agenciaid,Saldo,Identificador,PixConta) VALUES(4159, 1, 1, 300, '1001b6f8-4fdb-44dd-a63d-850e6bf5e1d3', '00000000-0000-0000-0000-000000000000')");
            migrationBuilder.Sql("INSERT INTO conta_corrente (Numero,ClienteId,Agenciaid,Saldo,Identificador,PixConta) VALUES(1789, 2, 2, 400, 'fd3a2250-27d9-48f4-ae89-9eea10a93396', '00000000-0000-0000-0000-000000000000')");

            migrationBuilder.Sql("INSERT INTO usuario (UserName, Email, Senha) VALUES ('admin','admin@email.com','0B267E19390CBE8D406F49C2D287473DDB60014B2E1588F431C6F2409511B8D6');");//senha01
            migrationBuilder.Sql("INSERT INTO usuario (UserName, Email, Senha) VALUES ('suporte', 'suporte@email.com', '8BA689219A79BBFB161F028A1C57CB02BB58241915D8EB53A7B6C347F64A8394');");//senha02

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete FROM cliente where id <=3 ");
            migrationBuilder.Sql("Delete FROM agencia where id <=2 ");
            migrationBuilder.Sql("Delete FROM conta_corrente where id<=2 ");
            migrationBuilder.Sql("Delete FROM usuario where id <= 2 ");
        }
    }
}
