import React, { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import postService from "../../services/postService";

const IMAGE_BASE_URL = "https://localhost:7067";

function BlogDetail() {

    const { id } = useParams();

    const [post, setPost] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        loadPost();
    }, [id]);

    const loadPost = async () => {

        try {

            const data =
                await postService.getPostById(id);

            setPost(data);

        }
        catch (error) {

            console.error(error);

        }
        finally {

            setLoading(false);

        }
    };

    if (loading) {

        return (
            <div className="container py-5 text-center">

                <div className="spinner-border text-primary"></div>

                <p className="mt-3">
                    Đang tải bài viết...
                </p>

            </div>
        );
    }

    if (!post) {

        return (
            <div className="container py-5 text-center">

                <h3>
                    Không tìm thấy bài viết
                </h3>

            </div>
        );
    }

    return (

        <div className="container py-5">

            {/* Breadcrumb */}

            <nav className="mb-4">

                <Link
                    to="/"
                    className="text-decoration-none"
                >
                    Trang chủ
                </Link>

                <span className="mx-2">/</span>

                <Link
                    to="/blog"
                    className="text-decoration-none"
                >
                    Tin tức
                </Link>

                <span className="mx-2">/</span>

                <span className="text-muted">
                    {post.title}
                </span>

            </nav>

            {/* Nội dung */}

            <div className="card border-0 shadow">

                {/* Hình ảnh */}

                {post.imageUrl && (

                    <img
                        src={
                            post.imageUrl.startsWith("http")
                                ? post.imageUrl
                                : IMAGE_BASE_URL + post.imageUrl
                        }
                        alt={post.title}
                        className="card-img-top"
                        style={{
                            maxHeight: "500px",
                            objectFit: "cover"
                        }}
                    />

                )}

                <div className="card-body p-5">

                    {/* Tiêu đề */}

                    <h1
                        className="fw-bold mb-3"
                        style={{
                            color: "#005088"
                        }}
                    >
                        {post.title}
                    </h1>

                    {/* Ngày đăng */}

                    <div className="text-muted mb-4">

                        <i className="fas fa-calendar-alt me-2"></i>

                        {post.createdDate
                            ? new Date(post.createdDate)
                                .toLocaleDateString("vi-VN")
                            : "Mới cập nhật"}

                    </div>

                    <hr />

                    {/* Nội dung */}

                    <div
                        className="mt-4"
                        style={{
                            lineHeight: "1.9",
                            fontSize: "17px"
                        }}
                        dangerouslySetInnerHTML={{
                            __html:
                                post.content ||
                                post.description ||
                                "<p>Chưa có nội dung.</p>"
                        }}
                    />

                </div>

            </div>

        </div>

    );
}

export default BlogDetail;