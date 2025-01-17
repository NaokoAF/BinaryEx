// Copyright (c) 2019-2022 Matthew Sitton <matthewsitton@gmail.com>
// MIT License - See LICENSE in the project root for license information.
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BinaryEx
{
    public static partial class BinaryEx
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt24LE(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= offset + 3);
            UInt32 val = 0;

            Unsafe.CopyBlockUnaligned(ref Unsafe.As<UInt32, byte>(ref val), ref MemoryMarshal.GetReference(buff.Slice(offset)), 3);
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt24BE(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= offset + 3);

            UInt32 val = 0;
            unsafe
            {
                byte* dst = (byte*)Unsafe.AsPointer(ref val) + 1;
                byte* start = (byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(buff.Slice(offset)));

                Unsafe.CopyBlockUnaligned(dst, start, 3);
            }
            return SwapEndianess(val);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt24LE(this ReadOnlySpan<byte> buff, int offset)
        {
            Int32 val = (Int32)ReadUInt24LE(buff, offset);
            return val - (val >> 23 << 24);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt24BE(this ReadOnlySpan<byte> buff, int offset)
        {
            Int32 val = (Int32)ReadUInt24BE(buff, offset);
            return val - (val >> 23 << 24);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ReadInt64LE(this ReadOnlySpan<byte> buff, int offset)
        {
            return (Int64)ReadUInt64LE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ReadInt64BE(this ReadOnlySpan<byte> buff, int offset)
        {
            return (Int64)ReadUInt64BE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt32LE(this ReadOnlySpan<byte> buff, int offset)
        {
            return (Int32)ReadUInt32LE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt32BE(this ReadOnlySpan<byte> buff, int offset)
        {
            return (Int32)ReadUInt32BE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int16 ReadInt16LE(this ReadOnlySpan<byte> buff, int offset)
        {
            return (Int16)ReadUInt16LE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int16 ReadInt16BE(this ReadOnlySpan<byte> buff, int offset)
        {
            return (Int16)ReadUInt16BE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ReadSByte(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= Unsafe.SizeOf<byte>());
            return (sbyte)buff[offset];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64LE(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt64>());
            return Unsafe.As<byte, UInt64>(ref MemoryMarshal.GetReference(buff.Slice(offset)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64BE(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt64>());
            return SwapEndianess(Unsafe.As<byte, UInt64>(ref MemoryMarshal.GetReference(buff.Slice(offset))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32LE(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt32>());
            return Unsafe.As<byte, UInt32>(ref MemoryMarshal.GetReference(buff.Slice(offset)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32BE(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt32>());
            return SwapEndianess(Unsafe.As<byte, UInt32>(ref MemoryMarshal.GetReference(buff.Slice(offset))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt16 ReadUInt16LE(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt16>());
            return Unsafe.As<byte, UInt16>(ref MemoryMarshal.GetReference(buff.Slice(offset)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt16 ReadUInt16BE(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt16>());
            return SwapEndianess(Unsafe.As<byte, UInt16>(ref MemoryMarshal.GetReference(buff.Slice(offset))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ReadByte(this ReadOnlySpan<byte> buff, int offset)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<byte>());
            return buff[offset];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReadBytes(this ReadOnlySpan<byte> buff, int offset, byte[] output, int count)
        {
            Debug.Assert(count < 0);
            Debug.Assert(buff.Length >= offset + count);
            Unsafe.CopyBlockUnaligned(ref output[0], ref MemoryMarshal.GetReference(buff.Slice(offset)), (uint)count);
            return (int)count;
        }

        public static int ReadCountLE<T>(this ReadOnlySpan<byte> buff, int offset, T[] output, int count) where T : unmanaged
        {
            Debug.Assert(count < 0);
            int outputByteSize = Unsafe.SizeOf<T>() * count;
            Debug.Assert(buff.Length >= offset + outputByteSize);
            unsafe
            {
                byte* outStart = (byte*)Unsafe.AsPointer<T>(ref output[0]);

                Unsafe.CopyBlockUnaligned(ref Unsafe.AsRef<byte>(outStart), ref MemoryMarshal.GetReference(buff.Slice(offset)), (uint)outputByteSize);
                return outputByteSize;
            }
        }
    }
}