using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.IO;
using SdlDotNet.Graphics;
using System.Drawing;
// This file is part of Mystery Dungeon eXtended.

// Copyright (C) 2015 Pikablu, MDX Contributors, PMU Staff

// Mystery Dungeon eXtended is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Mystery Dungeon eXtended is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Mystery Dungeon eXtended.  If not, see <http://www.gnu.org/licenses/>.


namespace Client.Logic.Graphics
{
    class SurfaceManager
    {
        #region Fields

        //private static string gfxEncryptionKey = @"^87cn23{}&*678!@f:98&(873320)*&}{fwe\d";
        private static string gfxEncryptionKey = @"&(*hvsdhj^%RtifgyhjHI&%tg8fhdiks*(&hfwielsaifudsoh&(*Y";

        #endregion Fields

        #region Enumerations

        public enum SurfaceSaveType
        {
            unknown,
            png,
            gif,
            jpg,
            bmp,
            ico,
            pmugfx
        }

        #endregion Enumerations

        #region Methods

        public static SurfaceSaveType DetermineSaveType(string filePath)
        {
            switch (System.IO.Path.GetExtension(filePath))
            {
                case ".png":
                    return SurfaceSaveType.png;
                case ".gif":
                    return SurfaceSaveType.gif;
                case ".jpg":
                case ".jpeg":
                    return SurfaceSaveType.jpg;
                case ".bmp":
                    return SurfaceSaveType.bmp;
                case ".ico":
                    return SurfaceSaveType.ico;
                case ".pmugfx":
                    return SurfaceSaveType.pmugfx;
                default:
                    return SurfaceSaveType.unknown;
            }
        }

        public static SdlDotNet.Graphics.Surface LoadSurface(string filePath)
        {
            return LoadSurface(filePath, false, false);
        }

        public static SdlDotNet.Graphics.Surface LoadSurface(string filePath, bool convert, bool transparent)
        {
            filePath = IO.Paths.CreateOSPath(filePath);
            Surface returnSurf;
            switch (System.IO.Path.GetExtension(filePath))
            {
                case ".pmugfx":
                    {
                        if (IO.IO.FileExists(filePath))
                        {
                            using (MemoryStream stream = new MemoryStream(DecryptSurface(filePath)))
                            {
                                Bitmap bitmap = (Bitmap)Image.FromStream(stream);
                                returnSurf = new Surface(bitmap);
                                if (convert)
                                {
                                    Surface returnSurf2 = returnSurf.Convert();
                                    returnSurf2.Transparent = true;
                                    returnSurf.Close();
                                    return returnSurf2;
                                }
                                else
                                {
                                    return returnSurf;
                                }
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                case ".gif":
                case ".png":
                default:
                    {
                        if (IO.IO.FileExists(filePath))
                        {
                            using (FileStream stream = File.OpenRead(filePath))
                            {
                                if (transparent)
                                {
                                    Bitmap bitmap = (Bitmap)Image.FromStream(stream);
                                    Bitmap clone = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                                    using (var gr = System.Drawing.Graphics.FromImage(clone))
                                    {
                                        gr.DrawImage(bitmap, new Rectangle(0, 0, clone.Width, clone.Height));
                                    }
                                    returnSurf = new Surface(clone);
                                }
                                else
                                {
                                    Bitmap bitmap = (Bitmap)Image.FromStream(stream);
                                    returnSurf = new Surface(bitmap);
                                }

                                if (convert)
                                {
                                    Surface returnSurf2 = returnSurf.Convert();
                                    returnSurf2.Transparent = true;
                                    returnSurf.Close();
                                    return returnSurf2;
                                }
                                else
                                {
                                    return returnSurf;
                                }
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
            }
        }

        public static void SaveSurface(SdlDotNet.Graphics.Surface surfaceToSave, string filePath)
        {
            System.Drawing.Image img = surfaceToSave.Bitmap;
            switch (DetermineSaveType(filePath))
            {
                case SurfaceSaveType.png:
                    img.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    break;
                case SurfaceSaveType.gif:
                    img.Save(filePath, System.Drawing.Imaging.ImageFormat.Gif);
                    break;
                case SurfaceSaveType.jpg:
                    img.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    break;
                case SurfaceSaveType.bmp:
                    img.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);
                    break;
                case SurfaceSaveType.ico:
                    img.Save(filePath, System.Drawing.Imaging.ImageFormat.Icon);
                    break;
                case SurfaceSaveType.pmugfx:
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] encryptedBytes = EncryptSurface(ms.ToArray());
                            System.IO.File.WriteAllBytes(filePath, encryptedBytes);
                        }
                    }
                    break;
            }
            img.Dispose();
        }

        internal static Surface LoadPMUGfx(byte[] imageBytes)
        {
            return LoadPMUGfx(imageBytes, false);
        }

        internal static Surface LoadPMUGfx(byte[] imageBytes, bool convert)
        {
            Surface returnSurf = new Surface(DecryptSurface(imageBytes));
            if (convert)
            {
                Surface returnSurf2 = returnSurf.Convert();
                returnSurf2.Transparent = true;
                returnSurf.Close();
                return returnSurf2;
            }
            else
            {
                return returnSurf;
            }
        }

        internal static byte[] DecryptSurface(byte[] imageBytes)
        {
            Security.Encryption encryption = new Security.Encryption(gfxEncryptionKey);
            byte[] decryptedSurface = encryption.DecryptBytes(imageBytes);
            return decryptedSurface;
        }

        internal static byte[] DecryptSurface(string filePath)
        {
            return DecryptSurface(System.IO.File.ReadAllBytes(filePath));
        }

        internal static byte[] EncryptSurface(string filePath)
        {
            return EncryptSurface(System.IO.File.ReadAllBytes(filePath));
        }

        internal static byte[] EncryptSurface(byte[] imageBytes)
        {
            Security.Encryption encryption = new Security.Encryption(gfxEncryptionKey);
            byte[] encryptedSurface = encryption.EncryptBytes(imageBytes);
            return encryptedSurface;
        }

        #endregion Methods
    }
}