using Volo.Abp;

namespace QianshiService.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name) 
            : base(QianshiServiceDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
