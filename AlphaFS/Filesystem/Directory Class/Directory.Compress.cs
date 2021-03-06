/*  Copyright (C) 2008-2017 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
 *  
 *  Permission is hereby granted, free of charge, to any person obtaining a copy 
 *  of this software and associated documentation files (the "Software"), to deal 
 *  in the Software without restriction, including without limitation the rights 
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 *  copies of the Software, and to permit persons to whom the Software is 
 *  furnished to do so, subject to the following conditions:
 *  
 *  The above copyright notice and this permission notice shall be included in 
 *  all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 *  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 *  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 *  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 *  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 *  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 *  THE SOFTWARE. 
 */

using System;
using System.IO;
using System.Security;

namespace Alphaleonis.Win32.Filesystem
{
   partial class Directory
   {
      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="path">A path that describes a directory to compress.</param>
      [SecurityCritical]
      public static void Compress(string path)
      {
         CompressDecompressCore(null, path, Path.WildcardStarMatchAll, null, null, true, PathFormat.RelativePath);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      [SecurityCritical]
      public static void Compress(string path, PathFormat pathFormat)
      {
         CompressDecompressCore(null, path, Path.WildcardStarMatchAll, null, null, true, pathFormat);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      [SecurityCritical]
      public static void Compress(string path, DirectoryEnumerationOptions options)
      {
         CompressDecompressCore(null, path, Path.WildcardStarMatchAll, options, null, true, PathFormat.RelativePath);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      [SecurityCritical]
      public static void Compress(string path, DirectoryEnumerationOptions options, PathFormat pathFormat)
      {
         CompressDecompressCore(null, path, Path.WildcardStarMatchAll, options, null, true, pathFormat);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="filters">The specification of custom filters to be used in the process.</param>
      [SecurityCritical]
      public static void Compress(string path, DirectoryEnumerationFilters filters)
      {
         CompressDecompressCore(null, path, Path.WildcardStarMatchAll, null, filters, true, PathFormat.RelativePath);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="filters">The specification of custom filters to be used in the process.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      [SecurityCritical]
      public static void Compress(string path, DirectoryEnumerationFilters filters, PathFormat pathFormat)
      {
         CompressDecompressCore(null, path, Path.WildcardStarMatchAll, null, filters, true, pathFormat);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      /// <param name="filters">The specification of custom filters to be used in the process.</param>
      [SecurityCritical]
      public static void Compress(string path, DirectoryEnumerationOptions options, DirectoryEnumerationFilters filters)
      {
         CompressDecompressCore(null, path, Path.WildcardStarMatchAll, options, filters, true, PathFormat.RelativePath);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      /// <param name="filters">The specification of custom filters to be used in the process.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      [SecurityCritical]
      public static void Compress(string path, DirectoryEnumerationOptions options, DirectoryEnumerationFilters filters, PathFormat pathFormat)
      {
         CompressDecompressCore(null, path, Path.WildcardStarMatchAll, options, filters, true, pathFormat);
      }




      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">A path that describes a directory to compress.</param>
      [SecurityCritical]
      public static void CompressTransacted(KernelTransaction transaction, string path)
      {
         CompressDecompressCore(transaction, path, Path.WildcardStarMatchAll, null, null, true, PathFormat.RelativePath);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      [SecurityCritical]
      public static void CompressTransacted(KernelTransaction transaction, string path, PathFormat pathFormat)
      {
         CompressDecompressCore(transaction, path, Path.WildcardStarMatchAll, null, null, true, pathFormat);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      [SecurityCritical]
      public static void CompressTransacted(KernelTransaction transaction, string path, DirectoryEnumerationOptions options)
      {
         CompressDecompressCore(transaction, path, Path.WildcardStarMatchAll, options, null, true, PathFormat.RelativePath);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      [SecurityCritical]
      public static void CompressTransacted(KernelTransaction transaction, string path, DirectoryEnumerationOptions options, PathFormat pathFormat)
      {
         CompressDecompressCore(transaction, path, Path.WildcardStarMatchAll, options, null, true, pathFormat);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="filters">The specification of custom filters to be used in the process.</param>
      [SecurityCritical]
      public static void CompressTransacted(KernelTransaction transaction, string path, DirectoryEnumerationFilters filters)
      {
         CompressDecompressCore(transaction, path, Path.WildcardStarMatchAll, null, filters, true, PathFormat.RelativePath);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="filters">The specification of custom filters to be used in the process.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      [SecurityCritical]
      public static void CompressTransacted(KernelTransaction transaction, string path, DirectoryEnumerationFilters filters, PathFormat pathFormat)
      {
         CompressDecompressCore(transaction, path, Path.WildcardStarMatchAll, null, filters, true, pathFormat);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      /// <param name="filters">The specification of custom filters to be used in the process.</param>
      [SecurityCritical]
      public static void CompressTransacted(KernelTransaction transaction, string path, DirectoryEnumerationOptions options, DirectoryEnumerationFilters filters)
      {
         CompressDecompressCore(transaction, path, Path.WildcardStarMatchAll, options, filters, true, PathFormat.RelativePath);
      }


      /// <summary>[AlphaFS] Compresses a directory using NTFS compression.</summary>
      /// <remarks>This will only compress the root items (non recursive).</remarks>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      /// <param name="filters">The specification of custom filters to be used in the process.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      [SecurityCritical]
      public static void CompressTransacted(KernelTransaction transaction, string path, DirectoryEnumerationOptions options, DirectoryEnumerationFilters filters, PathFormat pathFormat)
      {
         CompressDecompressCore(transaction, path, Path.WildcardStarMatchAll, options, filters, true, pathFormat);
      }




      /// <summary>Compress/decompress Non-/Transacted files/directories.</summary>
      /// <exception cref="ArgumentException"/>
      /// <exception cref="ArgumentNullException"/>
      /// <exception cref="DirectoryNotFoundException"/>
      /// <exception cref="IOException"/>
      /// <exception cref="NotSupportedException"/>
      /// <exception cref="UnauthorizedAccessException"/>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">A path that describes a directory to compress.</param>
      /// <param name="searchPattern">
      ///    The search string to match against the names of directories in <paramref name="path"/>.
      ///    This parameter can contain a combination of valid literal path and wildcard
      ///    (<see cref="Path.WildcardStarMatchAll"/> and <see cref="Path.WildcardQuestion"/>) characters, but does not support regular expressions.
      /// </param>
      /// <param name="options"><see cref="DirectoryEnumerationOptions"/> flags that specify how the directory is to be enumerated.</param>
      /// <param name="filters">The specification of custom filters to be used in the process.</param>
      /// <param name="compress"><see langword="true"/> compress, when <see langword="false"/> decompress.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      [SecurityCritical]
      internal static void CompressDecompressCore(KernelTransaction transaction, string path, string searchPattern, DirectoryEnumerationOptions? options, DirectoryEnumerationFilters filters, bool compress, PathFormat pathFormat)
      {
         var pathLp = Path.GetExtendedLengthPathCore(transaction, path, pathFormat, GetFullPathOptions.RemoveTrailingDirectorySeparator | GetFullPathOptions.FullCheck);

         if (null == options)
            options = DirectoryEnumerationOptions.None;

         // Traverse the source folder, processing files and folders.
         foreach (var fsei in EnumerateFileSystemEntryInfosCore<string>(null, transaction, pathLp, searchPattern, null, options | DirectoryEnumerationOptions.AsLongPath, filters, PathFormat.LongFullPath))
            Device.ToggleCompressionCore(transaction, true, fsei, compress, PathFormat.LongFullPath);

         // Compress the root directory, the given path.
         Device.ToggleCompressionCore(transaction, true, pathLp, compress, PathFormat.LongFullPath);
      }
   }
}
