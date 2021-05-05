using CrossPlatformDesktopProject.Sprites;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace CrossPlatformDesktopProject.InGameInfo
{
    public class Ammo
    {
        private const int maxAmmo = 10;
        private int currentAmmo;

        private const int ammoSpacing = 2;
        private const int verticalAmmoSpacing = 5;
        private readonly Vector2 topRightOffset = new Vector2(-10, 10);

        private ISprite blueBorder; //readonly
        private ISprite whiteBackground; //readonly
        private List<ISprite> ammo;

        private static Ammo ammoInstance = new Ammo();
        public static Ammo Instance
        {
            get => ammoInstance;
        }
        private Ammo()
        {
            currentAmmo = maxAmmo;
        }
        public void Initialize(float windowWidth)
        {
            Vector2 topLeft = new Vector2(windowWidth - (maxAmmo + 3) * ammoSpacing - maxAmmo * 4, 0) + topRightOffset;
            blueBorder = SpriteFactory.Instance.BlueAmmoBorderSprite(topLeft, new Vector2((maxAmmo + 3) * ammoSpacing + maxAmmo * 4, verticalAmmoSpacing * 2 + 11 + ammoSpacing * 2));
            whiteBackground = SpriteFactory.Instance.WhiteAmmoBackgroundSprite(topLeft + new Vector2(ammoSpacing, ammoSpacing), new Vector2((maxAmmo + 1) * ammoSpacing + maxAmmo * 4, verticalAmmoSpacing * 2 + 11));
            ammo = new List<ISprite>();
            for (int i = 0; i < maxAmmo; i++)
            {
                ammo.Add(SpriteFactory.Instance.BulletAmmoSprite(topLeft + new Vector2(2 * ammoSpacing + (4 + ammoSpacing) * i, ammoSpacing + verticalAmmoSpacing)));
            }
        }

        public void Draw()
        {
            blueBorder.Draw();
            whiteBackground.Draw();
            for (int i = 0; i < currentAmmo; i++) ammo[i].Draw();
        }
        public int AmmoCount
        {
            set
            {
                if (value > maxAmmo) value = maxAmmo;
                else if (value < 0) value = 0;
                currentAmmo = value;
            }
            get => currentAmmo;
        }
    }
}
