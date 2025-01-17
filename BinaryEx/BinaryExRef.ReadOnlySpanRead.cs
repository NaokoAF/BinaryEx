// Copyright (c) 2019-2022 Matthew Sitton <matthewsitton@gmail.com>
// MIT License - See LICENSE in the project root for license information.
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BinaryEx
{
    public static partial class BinaryExRef
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt24LE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            Int32 val = BinaryEx.ReadInt24LE(buff, offset);
            offset += 3;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt24BE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            Int32 val = BinaryEx.ReadInt24BE(buff, offset);
            offset += 3;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt24LE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            UInt32 val = BinaryEx.ReadUInt24LE(buff, offset);
            offset += 3;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt24BE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            UInt32 val = BinaryEx.ReadUInt24BE(buff, offset);
            offset += 3;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ReadInt64LE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            Int64 val = BinaryEx.ReadInt64LE(buff, offset);
            offset += 8;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ReadInt64BE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            Int64 val = BinaryEx.ReadInt64BE(buff, offset);
            offset += 8;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt32LE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            Int32 val = BinaryEx.ReadInt32LE(buff, offset);
            offset += 4;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt32BE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            Int32 val = BinaryEx.ReadInt32BE(buff, offset);
            offset += 4;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int16 ReadInt16LE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            Int16 val = BinaryEx.ReadInt16LE(buff, offset);
            offset += 2;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int16 ReadInt16BE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            Int16 val = BinaryEx.ReadInt16BE(buff, offset);
            offset += 2;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ReadSByte(this ReadOnlySpan<byte> buff, ref int offset)
        {
            sbyte val = BinaryEx.ReadSByte(buff, offset);
            offset += 1;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64LE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            UInt64 val = BinaryEx.ReadUInt64LE(buff, offset);
            offset += 8;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64BE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            UInt64 val = BinaryEx.ReadUInt64BE(buff, offset);
            offset += 8;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32LE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            UInt32 val = BinaryEx.ReadUInt32LE(buff, offset);
            offset += 4;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32BE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            UInt32 val = BinaryEx.ReadUInt32BE(buff, offset);
            offset += 4;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt16 ReadUInt16LE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            UInt16 val = BinaryEx.ReadUInt16LE(buff, offset);
            offset += 2;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt16 ReadUInt16BE(this ReadOnlySpan<byte> buff, ref int offset)
        {
            UInt16 val = BinaryEx.ReadUInt16BE(buff, offset);
            offset += 2;
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ReadByte(this ReadOnlySpan<byte> buff, ref int offset)
        {
            return buff[offset++];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ReadBytes(this ReadOnlySpan<byte> buff, ref int offset, byte[] output, int count)
        {
            offset += BinaryEx.ReadBytes(buff, offset, output, count);
        }

        public static void ReadCountLE<T>(this ReadOnlySpan<byte> buff, ref int offset, T[] output, int count) where T : unmanaged
        {
            offset += BinaryEx.ReadCountLE(buff, offset, output, count);
        }
    }
}