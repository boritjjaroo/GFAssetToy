#pragma once

using namespace System;

#include <stdint.h>

namespace TextureWrapper {
	public ref class ETCDecoder
	{
	public:
		int add(int a, int b);
		int decode_etc1(const uint8_t*, const long, const long, uint32_t*);
		int decode_etc2(const uint8_t*, const long, const long, uint32_t*);
		int decode_etc2a1(const uint8_t*, const long, const long, uint32_t*);
		int decode_etc2a8(const uint8_t*, const long, const long, uint32_t*);
		int decode_eacr(const uint8_t*, const long, const long, uint32_t*);
		int decode_eacr_signed(const uint8_t*, const long, const long, uint32_t*);
		int decode_eacrg(const uint8_t*, const long, const long, uint32_t*);
		int decode_eacrg_signed(const uint8_t*, const long, const long, uint32_t*);
	};
}
