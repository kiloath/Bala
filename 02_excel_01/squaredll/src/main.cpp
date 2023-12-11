#include "squaredll.h"
#include <vector>
#include <string>

int main() {
    squaredll();

    std::vector<std::string> vec;
    vec.push_back("test_package");

    squaredll_print_vector(vec);
}
