/*  Copyright (C) 2008-2015 Peter Palotas, Jeffrey Jangli, Alexandr Normuradov
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

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

namespace Alphaleonis.Win32.Filesystem
{
   public static partial class File
   {
      #region Public Methods

      /// <summary>Enumerates the streams of type :$DATA in the specified file or directory.</summary>
      /// <param name="path">The path to the file or directory to enumerate streams of.</param>
      /// <returns>The streams of type :$DATA in the specified file or directory.</returns>
      [SecurityCritical]
      public static IEnumerable<AlternateDataStreamInfo> EnumerateAlternateDataStreams(string path)
      {
         return EnumerateAlternateDataStreamsInternal(null, path, PathFormat.RelativePath);
      }

      /// <summary>Enumerates the streams of type :$DATA in the specified file or directory.</summary>
      /// <param name="path">The path to the file or directory to enumerate streams of.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>The streams of type :$DATA in the specified file or directory.</returns>
      [SecurityCritical]
      public static IEnumerable<AlternateDataStreamInfo> EnumerateAlternateDataStreams(string path, PathFormat pathFormat)
      {
         return EnumerateAlternateDataStreamsInternal(null, path, pathFormat);
      }

      /// <summary>Enumerates the streams of type :$DATA in the specified file or directory.</summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The path to the file or directory to enumerate streams of.</param>
      /// <returns>The streams of type :$DATA in the specified file or directory.</returns>
      [SecurityCritical]
      public static IEnumerable<AlternateDataStreamInfo> EnumerateAlternateDataStreams(KernelTransaction transaction, string path)
      {
         return EnumerateAlternateDataStreamsInternal(transaction, path, PathFormat.RelativePath);
      }

      /// <summary>Enumerates the streams of type :$DATA in the specified file or directory.</summary>
      /// <param name="transaction">The transaction.</param>
      /// <param name="path">The path to the file or directory to enumerate streams of.</param>
      /// <param name="pathFormat">Indicates the format of the path parameter(s).</param>
      /// <returns>The streams of type :$DATA in the specified file or directory.</returns>
      [SecurityCritical]
      public static IEnumerable<AlternateDataStreamInfo> EnumerateAlternateDataStreams(KernelTransaction transaction, string path, PathFormat pathFormat)
      {
         return EnumerateAlternateDataStreamsInternal(transaction, path, pathFormat);
      }

      #endregion
           

      #region Internal Methods

      internal static IEnumerable<AlternateDataStreamInfo> EnumerateAlternateDataStreamsInternal(KernelTransaction transaction, string path, PathFormat pathFormat)
      {
         using (var buffer = new SafeGlobalMemoryBufferHandle(Marshal.SizeOf(typeof(NativeMethods.WIN32_FIND_STREAM_DATA))))
         {
            path = Path.GetExtendedLengthPathInternal(transaction, path, pathFormat, GetFullPathOptions.RemoveTrailingDirectorySeparator | GetFullPathOptions.CheckInvalidPathChars | GetFullPathOptions.CheckAdditional);
            using (var handle = transaction == null 
               ? NativeMethods.FindFirstStreamW(path, NativeMethods.StreamInfoLevels.FindStreamInfoStandard, buffer, 0) 
               : NativeMethods.FindFirstStreamTransactedW(path, NativeMethods.StreamInfoLevels.FindStreamInfoStandard, buffer, 0, transaction.SafeHandle))
            {
               if (handle.IsInvalid)
               {
                  int errorCode = Marshal.GetLastWin32Error();
                  if (errorCode == Win32Errors.ERROR_HANDLE_EOF)
                     yield break;

                  NativeError.ThrowException(errorCode);
               }

               while (true)
               {
                  NativeMethods.WIN32_FIND_STREAM_DATA data = buffer.PtrToStructure<NativeMethods.WIN32_FIND_STREAM_DATA>();
                  yield return new AlternateDataStreamInfo(path, data);
                  if (!NativeMethods.FindNextStreamW(handle, buffer))
                  {
                     int lastError = Marshal.GetLastWin32Error();
                     if (lastError == Win32Errors.ERROR_HANDLE_EOF)
                        break;

                     NativeError.ThrowException(lastError, path);
                  }
               }
            }
         }
      }

      #endregion
   }
}