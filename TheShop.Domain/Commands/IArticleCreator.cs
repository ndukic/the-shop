using TheShop.Domain.Model;

namespace TheShop.Domain.Commands
{
    public interface IArticleCreator
    {
        void Save(Article article);
    }
}
