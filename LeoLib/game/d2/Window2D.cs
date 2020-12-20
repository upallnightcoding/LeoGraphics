using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using LeoLib.game.model.objects;
using LeoLib.script;
using LeoLib.game.d2;

namespace LeoLib.game
{
    public class Window2D : GameWindow
    {
        private Shader shader;

        //private Sprite sprite = null;

        private Camera camera;

        private bool firstMove = true;

        private Vector2 lastPos;

        private Scene2D scene = null;

        public Window2D(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            scene = new Scene2D();
        }


        protected override void OnLoad()
        {
            GL.ClearColor(0.7f, 0.7f, 0.7f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            //sprite = new Sprite();
            //sprite.OnLoad();

            scene.Add(new Sprite("face.png"));

            Sprite ss1 = new Sprite("container.png");
            ss1.Translate(1.0f, 0.0f, 0.0f);
            scene.Add(ss1);

            Sprite ss2 = new Sprite("awesomeface.png");
            ss2.Translate(2.0f, 0.0f, 0.0f);
            scene.Add(ss2);

            Sprite ss3 = new Sprite("container2.png");
            ss3.Translate(3.0f, 0.0f, 0.0f);
            scene.Add(ss3);

            Sprite ss4 = new Sprite("face.png");
            ss4.Translate(4.0f, 0.0f, 0.0f);
            scene.Add(ss4);

            shader = new Shader(Constant.SHADER_VERT, Constant.SHADER_FRAG);
           
            camera = new Camera(Vector3.UnitZ * 5.0f, Size.X / (float) Size.Y);

            CursorGrabbed = true;

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            float deltaTime = (float) e.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            scene.Update(deltaTime); 

            scene.Render(camera, shader);

            SwapBuffers();

            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            if (!IsFocused) // check to see if the window is focused
            {
                return;
            }

            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            const float cameraSpeed = 1.5f;
            const float sensitivity = 0.2f;

            if (input.IsKeyDown(Keys.W))
            {
                camera.Position += camera.Front * cameraSpeed * (float)e.Time; // Forward
            }

            if (input.IsKeyDown(Keys.S))
            {
                camera.Position -= camera.Front * cameraSpeed * (float)e.Time; // Backwards
            }

            if (input.IsKeyDown(Keys.A))
            {
                camera.Position -= camera.Right * cameraSpeed * (float)e.Time; // Left
            }

            if (input.IsKeyDown(Keys.D))
            {
                camera.Position += camera.Right * cameraSpeed * (float)e.Time; // Right
            }

            if (input.IsKeyDown(Keys.Space))
            {
                camera.Position += camera.Up * cameraSpeed * (float)e.Time; // Up
            }

            if (input.IsKeyDown(Keys.LeftShift))
            {
                camera.Position -= camera.Up * cameraSpeed * (float)e.Time; // Down
            }

            // Get the mouse state
            var mouse = MouseState;

            if (firstMove) // this bool variable is initially set to true
            {
                lastPos = new Vector2(mouse.X, mouse.Y);
                firstMove = false;
            }
            else
            {
                // Calculate the offset of the mouse position
                var deltaX = mouse.X - lastPos.X;
                var deltaY = mouse.Y - lastPos.Y;
                lastPos = new Vector2(mouse.X, mouse.Y);

                // Apply the camera pitch and yaw (we clamp the pitch in the camera class)


                //camera.Yaw += deltaX * sensitivity;
                //camera.Pitch -= deltaY * sensitivity; // reversed since y-coordinates range from bottom to top
            }

            base.OnUpdateFrame(e);
        }

        // In the mouse wheel function we manage all the zooming of the camera
        // this is simply done by changing the FOV of the camera
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            camera.Fov -= e.OffsetY;
            base.OnMouseWheel(e);
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, Size.X, Size.Y);
            // We need to update the aspect ratio once the window has been resized
            camera.AspectRatio = Size.X / (float)Size.Y;
            base.OnResize(e);
        }

        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);

            scene.OnUnLoad();

            GL.DeleteProgram(shader.handle);
            //GL.DeleteTexture(texture1.handle);
            //GL.DeleteTexture(texture2.handle);

            base.OnUnload();
        }
    }
}
