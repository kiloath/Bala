#pragma once

#include <vector>
#include <string>


#ifdef _WIN32
  #define SQUAREDLL_EXPORT __declspec(dllexport)
#else
  #define SQUAREDLL_EXPORT
#endif

SQUAREDLL_EXPORT void squaredll();
SQUAREDLL_EXPORT void squaredll_print_vector(const std::vector<std::string> &strings);
