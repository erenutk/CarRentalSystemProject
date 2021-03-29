using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added(string AddedObject)
        {
            return  $"{AddedObject} kayıt işlemi başarılı";
        }
        //Car
        public static string CarNameError = "Araba ismi minimum 2 karakter olmalıdır.\n" + CarAddError;

        public static string CarAdded = "Araç kayıt işlemi başarılı";
        public static string CarDeleted = "Araç silme işlemi başarılı";
        public static string CarUpdated = "Araç güncelleme işlemi başarılı";
        public static string CarsListed = "Mevcut araçlar";
        public static string CarUpdateError = "Araç güncellenemedi";
        public static string CarInvalid = "Araç mevcut değil";
        public static string CarAddError = "Araç eklenemedi";

        //Color

        public static string ColorAdded = "Renk kayıt işlemi başarılı";
        public static string ColorDeleted = "Renk silme işlemi başarılı";
        public static string ColorUpdated = "Renk güncelleme işlemi başarılı";
        public static string ColorsListed = "Mevcut renkler ";
        public static string ColorInvalid = "Renk mevcut değil";

        //Brand

        public static string BrandAdded = "Marka kayıt işlemi başarılı";
        public static string BrandDeleted = "Marka silme işlemi başarılı";
        public static string BrandUpdated = "Marka güncelleme işlemi başarılı";
        public static string BrandsListed = "Mevcut markalar";
        public static string BrandInvalid = "Marka mevcut değil ";

        //User
        
        public static string UserAdded = "Kullanıcı kayıt işlemi başarılı";
        public static string UserDeleted = "Kullanıcı silme işlemi başarılı";
        public static string UserUpdated = "Kullanıcı güncelleme işlemi başarılı";

        //Customer

        public static string CustomerAdded = "Müşteri kayıt işlemi başarılı";
        public static string CustomerDeleted = "Müşteri silme işlemi başarılı";
        public static string CustomerUpdated = "Müşteri güncelleme işi başarılı";

        //Rental

        public static string RentalAdded = "Kiralama işlemi başarılı";
        public static string RentalDeleted = "Kiralama silme işlemi başarılı";
        public static string RentalUpdated = "Kiralama güncelleme işlemi başarılı";
        public static string NotReturned = "Araç henüz teslim edilmedi";
        public static string RentalListed = "Kiralamalar listelendi";

        //Images

        public static string MaintenanceTime = "Bakım zamanı";
        public static string CarImageLimitExceeded = "Bir aracın en fazla 5 fotoğrafı olabilir";
        public static string ImageAdded = "Resim ekleme işlemi başarılı ";
        public static string ImageDeleted = "Resim silme işlemi başarılı ";
        public static string ImageUpdated = "Resim güncelleme işlemi başarılı ";
   
        //Security

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        
    }
}
