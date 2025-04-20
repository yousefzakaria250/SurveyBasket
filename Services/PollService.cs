
namespace SurveyBasket.Api.Services
{
    public class PollService : IPollService
    {
        private static List<Poll> _polls = [
           new Poll {
                Id = 1,
                Title = "Poll1",
                Description =" MY Poll 1 ."
            },
              new Poll {
                Id = 2,
                Title = "Poll1",
                Description =" MY Poll 1 ."
            },
              new Poll {
                Id = 3,
                Title = "Poll1",
                Description =" MY Poll 1 ."
            }
       ];
        public IEnumerable<Poll> GetAll() => _polls;
        public Poll? Get(int Id) => _polls.SingleOrDefault(d => d.Id == Id);

        public Poll Add(Poll poll)
        {
            poll.Id = _polls.Count() + 1;   
            _polls.Add(poll);
            return poll;
        }

        public bool Update(int Id, Poll poll)
        {
            var currentPool = Get(Id);  
            if(currentPool is null)
                return false;
            currentPool.Title = poll.Title;
            currentPool.Description = poll.Description;
            return true;    
        }

        public bool Delete(int Id)
        {
            var poll = Get(Id);
            if (poll is null) return false;
            _polls.Remove(poll);
            return true;
        }
    }
}
