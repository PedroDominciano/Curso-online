using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest
    {
        [Fact]
        public void DeveCriarCurso()
        {
            //Arranje
            const string nome = "Informática básica";
            const double cargaHoraria = 80;
            const string publicoAlvo = "Estudante";
            const double valor = 950;

            //Action
            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);

            //Assert
            Assert.Equal(nome, curso.Nome);
            Assert.Equal(cargaHoraria, curso.CargaHoraria);
            Assert.Equal(publicoAlvo, curso.PublicoAlvo);
            Assert.Equal(valor, curso.Valor);

        }

        [Fact]
        public void DeveGerarErroCasoInformarAlgoEmBranco()
        {
            //Arranje
            const string nome = "";
            const double cargaHoraria = 0;
            const string publicoAlvo = "";
            const double valor = 0;

            //Action
            var curso = new Curso(nome, cargaHoraria, publicoAlvo, valor);
            var bInformacesValidas = curso.ValidarInformacoes();

            //Assert
            Assert.False(bInformacesValidas);

        }
    }

    public class Curso
    {
        public Curso(string nome, double cargaHoraria, string publicoAlvo, double valor)
        {
            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public bool ValidarInformacoes()
        {
            return ((Nome != "") && (CargaHoraria != 0) && (PublicoAlvo != "") && (Valor != 0));
        }

        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public string PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

    }
}
