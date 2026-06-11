import React, { useState, useEffect } from 'react';
import productService from '../../services/productService';
import ProductCard from '../../components/ProductCard';

function ProductGrid({ activeCategoryId }) {

    const [products, setProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchAllProducts = async () => {
            try {
                setLoading(true);
                const data = await productService.getAllProducts();

                // 🔥 chống undefined
                setProducts(Array.isArray(data) ? data : []);

            } catch (error) {
                console.error("Lỗi hệ thống khi tải danh sách sản phẩm:", error);
            } finally {
                setLoading(false);
            }
        };

        fetchAllProducts();
    }, []);

    // 🔥 luôn đảm bảo array
    const safeProducts = Array.isArray(products) ? products : [];

    // 🔥 FILTER CATEGORY
    // Lọc sản phẩm theo danh mục đang chọn
    const filteredProducts = activeCategoryId === null
        ? products
        : products.filter(p => p.categoryProductId === activeCategoryId);


    if (loading) {
        return (
            <div className="container my-5 text-center">
                <div className="spinner-border text-primary" role="status"></div>
                <p className="mt-2 text-muted">
                    Đang tải danh sách trang phục mới nhất...
                </p>
            </div>
        );
    }

    return (
        <section className="product-grid-wrapper py-4">
            <div className="container">

                {/* HEADER */}
                <div className="section-heading mb-4 d-flex justify-content-between align-items-center border-bottom pb-2">

                    <h4 className="font-weight-bold text-uppercase m-0" style={{ color: '#005088' }}>
                        <i className="fas fa-sparkles mr-2 text-warning"></i>
                        Sản phẩm nổi bật
                    </h4>

                    <span className="text-muted" style={{ fontSize: '14px' }}>
                        Hiển thị ({filteredProducts.length}) sản phẩm
                    </span>

                </div>

                {/* GRID */}
                <div className="row">

                    {filteredProducts.map((product) => (
                        <div
                            className="col-xl-3 col-lg-4 col-sm-6 col-12 mb-4"
                            key={product.id}
                        >
                            <ProductCard item={product} />
                        </div>
                    ))}

                </div>

            </div>
        </section>
    );
}

export default ProductGrid;