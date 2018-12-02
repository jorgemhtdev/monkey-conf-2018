using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Threading.Tasks;

namespace MonkeyConf.Services.Camera
{
    public class CameraService
    {
        private static CameraService _instance;

        public static CameraService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CameraService();

                return _instance;
            }
        }

        public async Task<MediaFile> PickPhotoAsync()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return null;
            }

            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                status = results[Permission.Camera];
            }

            if (status == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.PickPhotoAsync();

                if (file == null)
                {
                    return null;
                }

                return file;
            }

            return null;
        }

        public async Task<MediaFile> TakePhotoAsync()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return null;
            }

            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera });
                status = results[Permission.Camera];
            }

            if (status == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    CompressionQuality = 92,
                    PhotoSize = PhotoSize.Medium,
                    SaveToAlbum = true,
                    Name = "MonkeyConf2018.jpg"
                });

                if (file == null)
                {
                    return null;
                }

                return file;
            }

            return null;
        }
    }
}