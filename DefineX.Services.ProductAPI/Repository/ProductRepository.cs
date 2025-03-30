using AutoMapper;
using DefineX.Services.ProductAPI.dbcontexts;
using DefineX.Services.ProductAPI.dto;
using DefineX.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using Image = DefineX.Services.ProductAPI.Models.Image;


namespace DefineX.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;


        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {

            Product product = _mapper.Map<ProductDto, Product>(productDto);

            if (product.id > 0)
            {
                _db.Products.Update(product);
                ImageUpdate(productDto.Images[0]);
                ImageUpdate(productDto.Images[1]);
                VariantUpdate(productDto.Variants[0]);
                VariantUpdate(productDto.Variants[1]);
            }
            else
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                int productId = product.id;
                for (int i = 0; i < productDto.Variants.Length; i++)
                {
                    productDto.Variants[i].image_id = -1;
                    productDto.Variants[i].id = productId;
                    _db.Variants.Add(productDto.Variants[i]);
                    _db.SaveChanges();

                    int variantId = productDto.Variants[i].variant_id;

                    productDto.Images[i].id = productId;
                    productDto.Images[i].variant_id = new int[] { variantId };
                    productDto.Images[i].src = "";
                    _db.ProductImages.Add(productDto.Images[i]);
                    _db.SaveChanges();

                    int imageId = productDto.Images[i].image_id;
                    productDto.Variants[i].image_id = imageId;
                    productDto.Images[i].src = productDto.Images[i].image_id + ".png";
                    _db.ProductImages.Update(productDto.Images[i]);
                    _db.Variants.Update(productDto.Variants[i]);
                    _db.SaveChanges();
                }


            }
            await _db.SaveChangesAsync();

            return productDto;
        }


        public void ImageUpdate(Image Image)
        {
            Image oldVersionImage = _db.ProductImages.FirstOrDefault(p => p.image_id == Image.image_id);
            oldVersionImage.alt = Image.alt;
            _db.ProductImages.Update(oldVersionImage);
        }
        public Variant VariantUpdate(Variant variant)
        {
            Variant oldVersionVariant = _db.Variants.FirstOrDefault(p => p.variant_id == variant.variant_id);
            oldVersionVariant.sku = variant.sku;
            oldVersionVariant.color = variant.color;
            oldVersionVariant.size = variant.size;
            _db.Variants.Update(oldVersionVariant);
            return oldVersionVariant;
        }


        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _db.Products.FirstOrDefaultAsync(u => u.id == productId);
                var productsToDeleteImage = await _db.ProductImages.Where(u => u.id == productId).ToListAsync();
                var productsToDeleteVariants = await _db.Variants.Where(u => u.id == productId).ToListAsync();
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product); //delete from Product where Id=productId
                _db.ProductImages.RemoveRange(productsToDeleteImage);
                _db.Variants.RemoveRange(productsToDeleteVariants);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {

            ProductDto productDto = await _db.Products
        .Where(p => p.id == productId)
        .Select(p => new ProductDto
        {
            id = p.id,
            Title = p.Title,
            Description = p.Description,
            Type = p.Type,
            Brand = p.Brand,
            CategoryName = p.CategoryName,
            Collection = p.Collection,
            Price = p.Price,
            Tags = p.tags,
            IsHot = p.IsHot,
            Discount = p.discount,
            IsNew = p.IsNew,
            Variants = _db.Variants.Where(v => v.id == p.id).ToArray(),
            Images = _db.ProductImages.Where(i => i.id == p.id).ToArray()
        })
        .FirstOrDefaultAsync();

            return _mapper.Map<ProductDto>(productDto);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            List<ProductDto> productDtoList = await _db.Products
            .Select(p => new ProductDto
            {
                id = p.id,
                Title = p.Title,
                Description = p.Description,
                Type = p.Type,
                Brand = p.Brand,
                CategoryName = p.CategoryName,
                Collection = p.Collection,
                Price = p.Price,
                Tags = p.tags,
                IsHot = p.IsHot,
                Discount = p.discount,
                IsNew = p.IsNew,
                Variants = _db.Variants.Where(v => v.id == p.id).ToArray(),
                Images = _db.ProductImages.Where(i => i.id == p.id).ToArray()
            }).ToListAsync();
            return _mapper.Map<List<ProductDto>>(productDtoList);
        }
    }
}