using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NewManager : INewService
    {
        INewDal _NewDal;
        public NewManager(INewDal NewDal) {
        
            _NewDal = NewDal;
        
        }

        public void CreateNews(New value) => _NewDal.Insert(value);

        public List<New> GetAllNews() => _NewDal.List();


        public New GetNews(int id) => _NewDal.Get(x => x.New_Id == id);
    }
}
