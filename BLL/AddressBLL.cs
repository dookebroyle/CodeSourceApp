using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class AddressBLL
    {
        AddressDAO dao = new AddressDAO();
        public bool AddAddress(AddressDTO model)
        {
            Address address = new Address
            {
                Address1 = model.Address,
                Email = model.Email,
                Phone = model.Phone,
                Phone2 = model.Phone2,
                Fax = model.Fax,
                MapPathLarge = model.MapPathLarge,
                MapPathSmall = model.MapPathSmall,
                AddDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                LastUpdateUserID = UserStatic.UserID,
            };
            if(model.Fax == null)
            {
                address.Fax = "0000000000";
            }
            int addressID = dao.AddAddress(address);
            LogDAO.AddLog(General.ProcessType.AddressAdd, General.TableName.Address, addressID);
            return true;
        }

        public List<AddressDTO> GetAddresses()
        {
            List<AddressDTO> list = dao.GetAddresses();
            return list;
        }


        public AddressDTO GetAddressByID(int iD)
        {
            return dao.GetAddressByID(iD);
        }
        public bool UpdateAddress(AddressDTO model)
        {
            dao.UpdateAddress(model);
            LogDAO.AddLog(General.ProcessType.AddressUpdate, General.TableName.Address, model.ID);
            return true;
        }

        public void DeleteAddress(int iD)
        {
            dao.DeleteAddress(iD);
            LogDAO.AddLog(General.ProcessType.AddressDelete, General.TableName.Address, iD);
        }
    }
}
