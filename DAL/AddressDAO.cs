using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AddressDAO : PostContext
    {
        public int AddAddress(Address address)
        {

            try
            {
                db.Addresses.Add(address);
                db.SaveChanges();
                return address.ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AddressDTO> GetAddresses()
        {
            try
            {
                List<AddressDTO> addresslist = new List<AddressDTO>();
                List<Address> list = db.Addresses.Where(x => x.isDeleted == false).OrderBy(x => x.AddDate).ToList();

                foreach (var item in list)
                {
                    AddressDTO dto = new AddressDTO
                    {
                        ID = item.ID,
                        Address = item.Address1,
                        Email = item.Email,
                        Phone = item.Phone,
                        Phone2 = item.Phone2,
                        Fax = item.Fax,
                        MapPathLarge = item.MapPathLarge,
                        MapPathSmall = item.MapPathSmall
                    };
                    addresslist.Add(dto);
                }
                return addresslist;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AddressDTO GetAddressByID(int iD)
        {
            try
            {
                Address address = db.Addresses.First(x => x.ID == iD);
                AddressDTO dto = new AddressDTO
                {
                    ID = address.ID,
                    Address = address.Address1,
                    Email = address.Email,
                    Phone = address.Phone,
                    Phone2 = address.Phone2,
                    Fax = address.Fax,
                    MapPathLarge = address.MapPathLarge,
                    MapPathSmall = address.MapPathSmall
                };
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteAddress(int iD)
        {
            try
            {
                Address ads = db.Addresses.First(x => x.ID == iD);
                ads.isDeleted = true;
                ads.DeletedDate = DateTime.Now;
                ads.LastUpdateDate = DateTime.Now;
                ads.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateAddress(AddressDTO model)
        {
            try
            {
                Address address = db.Addresses.First(x => x.ID == model.ID);
                address.Address1 = model.Address;
                address.Email = model.Email;
                address.Phone = model.Phone;
                address.Phone2 = model.Phone2;
                address.Fax = model.Fax;
                address.MapPathLarge = model.MapPathLarge;
                address.MapPathSmall = model.MapPathSmall;
                address.LastUpdateDate = DateTime.Now;
                address.LastUpdateUserID = UserStatic.UserID;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
