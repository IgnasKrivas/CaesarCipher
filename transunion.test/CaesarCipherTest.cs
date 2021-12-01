using System;
using Xunit;
using transunion;
using System.Threading.Tasks;

namespace transunion.test
{
    public class CaesarCipherTest
    {
        
        [Theory]
        [InlineData('a',1,'b')]
        [InlineData('0',1,'0')]
        [InlineData('A',1,'B')]
        [InlineData('a',-1,'z')]
        [InlineData('A',-1,'Z')]
        public void cipher_Normal_GoodResults(char ch,int key,char expectedch)
        {
            // Arrange
            var caesarCipher = new CaesarCipher();
            // Act
            var result = caesarCipher.cipher(
                ch,
                key);
            // Assert
            Assert.Equal(expectedch, result);
        }

        [Theory]
        [InlineData("test",1,"uftu")]
        [InlineData("test",-1,"sdrs")]
        public void Encipher_Normal_GoodResult(string input, int key, string goodExpectedInput)
        {
            // Arrange
            var caesarCipher = new CaesarCipher();
            // Act
            var result = caesarCipher.Encipher(
                input,
                key);
            // Assert
            Assert.Equal(goodExpectedInput, result);
        }

        [Theory]
        [InlineData("uftu", 1, "test")]
        [InlineData("sdrs", -1, "test")]
        public void Decipher_Normal_GoodResult(string input, int key, string goodExpectedInput)
        {
            // Arrange
            var caesarCipher = new CaesarCipher();
            // Act
            var result = caesarCipher.Decipher(
                input,
                key);
            // Assert
            Assert.Equal(goodExpectedInput, result);
        }

        [Fact]
        public void GetText_Normal_GoodResult()
        {
            // Arrange
            var caesarCipher = new CaesarCipher();
            // Act
            var result = caesarCipher.GetText("test");
            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
        
        [Fact]
        public void GetKey_BadInput_OverflowException()
        {
            // Arrange
            var caesarCipher = new CaesarCipher();
            var key = "11111111111111111111111111111111111111111111111111111111";
            // Act
            // Assert
            Assert.Throws<OverflowException>(() => caesarCipher.GetKey(key));
        }

        [Fact]
        public void GetKey_BadInput_FormatException()
        {
            // Arrange
            var caesarCipher = new CaesarCipher();
            var key = "-";
            // Act
            // Assert
            Assert.Throws<FormatException>(() => caesarCipher.GetKey(key));
        }

        [Fact]
        public void GetKey_Normal_GoodResult()
        {
            // Arrange
            var caesarCipher = new CaesarCipher();
            var key = "1";
            // Act
            var result = caesarCipher.GetKey(key);
            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(int.Parse(key), result);
        }
    }
}
