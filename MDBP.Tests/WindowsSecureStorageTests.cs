#if NET9_0_WINDOWS
using MusicDBPlayground.DiscogsIntegration.Security;

namespace MDBP.Tests
{
    public class WindowsSecureStorageTests
    {
        private const string TestKey = "unit_test_key";

        [Fact]
        public void SaveAndLoad_ReturnsOriginalValue()
        {
            // Arrange
            var storage = new WindowsSecureStorage();
            var originalValue = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

            // Act
            storage.Save(TestKey, originalValue);
            var loadedValue = storage.Load(TestKey);

            // Assert
            Assert.Equal(originalValue, loadedValue);
        }

        [Fact]
        public void StoredFile_IsNotPlaintext()
        {
            // Arrange
            var storage = new WindowsSecureStorage();
            var originalValue = "SuperSecretPassword123!";
            storage.Save(TestKey, originalValue);

            var path = GetPath(TestKey);
            var fileContents = File.ReadAllText(path);

            // Assert that the plaintext value is NOT stored
            Assert.DoesNotContain(originalValue, fileContents);
        }

        [Fact]
        public void Load_NonexistentKey_Throws()
        {
            // Arrange
            var storage = new WindowsSecureStorage();
            var fakeKey = "nonexistent_key_" + Guid.NewGuid();

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => storage.Load(fakeKey));
        }

        private static string GetPath(string key)
        {
            var dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "DiscogsIntegration", "Secrets");

            return Path.Combine(dir, key);
        }
    }
}
#endif
