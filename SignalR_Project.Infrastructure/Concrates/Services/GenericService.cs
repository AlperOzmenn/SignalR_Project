using AutoMapper;
using SignalR_Project.Application.Interfaces;
using SignalR_Project.Core.Commons;
using SignalR_Project.Core.Interfaces;
using SignalR_Project.Core.UnitOfWorks;

namespace SignalR_Project.Infrastructure.Concrates.Services
{
    public class GenericService<T> : IGenericService<T> where T : IBaseEntity, new()
    {
        protected readonly IRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public GenericService(IRepository<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Ekleme
        public async Task AddAsync(T model)
        {
            var entity = _mapper.Map<T>(model);
            _repository.Add(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        // Silme
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id, ignoreFilters: true);
            if (entity is not null)
            {
                _repository.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        // Bütün verileri getirme
        public async Task<IEnumerable<T>> GetAllAsync(bool ignoreFilters = false)
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<T>>(entities);
        }

        //  İd ye göre veri getirme
        public async Task<T?> GetByIdAsync(Guid id, bool ignoreFilters = false)
        {
            var entity = await _repository.GetByIdAsync(id, ignoreFilters);
            return _mapper.Map<T>(entity);
        }

        // Soft Delete
        public async Task SoftDeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is not null)
            {
                entity.SoftDelete();
                _repository.Update(entity);
                await _unitOfWork.SaveChangesAsync();
            }
        }
         // Güncelleme
        public async Task UpdateAsync(T model)
        {
            var idProp = model.GetType().GetProperty("Id");
            if (idProp is null)
                throw new Exception("İd bulunamadı");

            var id = (Guid)idProp.GetValue(model);
            var entity = await _repository.GetByIdAsync(id);

            if (entity is null)
                throw new Exception("Güncellenecek veri bulunamadı!");

            _mapper.Map(model, entity);
            entity.Update();
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
