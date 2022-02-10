using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CursoOnline.DominioTest
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "Variavel1MustBeEqualToVariavel2")]
        public void Variavel1MustBeEqualToVariavel2()
        {
            //Arrange
            var variavel1 = 1;
            var variavel2 = 1;

            //Action
            variavel1 = variavel2;

            //Assert
            Assert.Equal(variavel1, variavel2);
        }
    }
}
