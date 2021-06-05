#pragma once
#include <stdint.h>


int decode_etc2a8(const uint8_t * data, const long w, const long h, uint32_t * image);
