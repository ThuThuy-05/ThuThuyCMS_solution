import React, { useEffect, useState } from "react";
import PostCard from "../../components/PostCard";
import BlogSidebar from "./BlogSidebar";
import postService from "../../services/postService";

function Blog() {

    const [posts, setPosts] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        loadPosts();
    }, []);

    const loadPosts = async () => {

        try {

            setLoading(true);

            const data =
                await postService.getAllPosts();

            setPosts(data);

        }
        catch (error) {
            console.error(error);
        }
        finally {
            setLoading(false);
        }
    };

    const handleCategorySelect = async (categoryId) => {

        try {

            setLoading(true);

            if (categoryId === null) {

                const data =
                    await postService.getAllPosts();

                setPosts(data);

            }
            else {

                const data =
                    await postService.getPostsByCategory(categoryId);

                setPosts(data);

            }

        }
        catch (error) {
            console.error(error);
        }
        finally {
            setLoading(false);
        }
    };

    return (
        <>
            {/* Breadcrumb */}
            <div className="container mt-4">

                <nav aria-label="breadcrumb">
                    <ol className="breadcrumb bg-transparent px-0 mb-4">

                        <li className="breadcrumb-item">
                            <a
                                href="/"
                                className="fw-bold text-primary text-decoration-none"
                            >
                                Trang chủ
                            </a>
                        </li>

                        <li
                            className="breadcrumb-item active"
                            aria-current="page"
                        >
                            Tin tức
                        </li>

                    </ol>
                </nav>

            </div>

            {/* Tiêu đề trang */}
            <section className="mb-5">
                <div className="container">

                    <div
                        className="bg-white shadow-sm p-5"
                        style={{
                            borderRadius: "10px"
                        }}
                    >
                        <h1
                            className="fw-bold mb-3"
                            style={{
                                color: "#333"
                            }}
                        >
                            Danh sách bài viết
                        </h1>

                        <div
                            style={{
                                width: "80px",
                                height: "4px",
                                background: "#11CAA0"
                            }}
                        >
                        </div>

                    </div>

                </div>
            </section>

            {/* Nội dung */}
            <div className="container">

                <div className="row">

                    {/* Sidebar */}
                    <div className="col-lg-3 mb-4">

                        <BlogSidebar
                            onCategorySelect={handleCategorySelect}
                        />

                    </div>

                    {/* Danh sách bài viết */}
                    <div className="col-lg-9">

                        <div className="d-flex justify-content-between align-items-center mb-4">

                            <h4
                                className="fw-bold"
                                style={{
                                    color: "#005088"
                                }}
                            >
                                Tất cả bài viết
                            </h4>

                            <span className="badge bg-primary">
                                {posts.length} bài viết
                            </span>

                        </div>

                        {loading ? (

                            <div className="text-center py-5">

                                <div
                                    className="spinner-border text-primary"
                                    role="status"
                                >
                                </div>

                                <p className="mt-3">
                                    Đang tải dữ liệu...
                                </p>

                            </div>

                        ) : (

                            <div className="row">

                                {posts.length > 0 ? (

                                    posts.map((post) => (

                                        <div
                                            key={post.id}
                                            className="col-md-6 col-xl-4 mb-4"
                                        >
                                            <PostCard post={post} />
                                        </div>

                                    ))

                                ) : (

                                    <div className="col-12">

                                        <div className="alert alert-warning">
                                            Không tìm thấy bài viết nào.
                                        </div>

                                    </div>

                                )}

                            </div>

                        )}

                    </div>

                </div>

            </div>
        </>
    );
}

export default Blog;