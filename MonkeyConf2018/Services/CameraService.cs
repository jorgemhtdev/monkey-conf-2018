namespace MonkeyConf2018.Services
{
    using System.Threading.Tasks;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions;

    public class CameraService
    {
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
    }
}
