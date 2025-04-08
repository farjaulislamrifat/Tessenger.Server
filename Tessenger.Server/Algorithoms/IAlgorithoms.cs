namespace Tessenger.Server.Algorithoms
{
    public interface IAlgorithoms
    {
        public Task<string> Encryption(string text, string publickey, string secretkey);
        public Task<string> Decryption(string text, string publickey, string secretkey);

    }
}
