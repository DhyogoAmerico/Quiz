namespace Quiz.Domain.Service;

public interface ICryptoService
{
    string Encrypt(string key);
    string Decrypt(string key);
}
