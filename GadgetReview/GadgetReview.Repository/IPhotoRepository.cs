using GadgetReview.Models.Photo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GadgetReview.Repository
{
    public interface IPhotoRepository
    {
        public Task<Photo> InsertAsync(PhotoCreate photoCreate, int applicationUserId);

        public Task<Photo> GetAsync(int photoId);

        public Task<List<Photo>> GetAllByUserIdAsync(int applicationUserId);

        public Task<int> DeletetAsync(int photoId);
    }
}
