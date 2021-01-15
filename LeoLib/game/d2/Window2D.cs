using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using LeoLib.game.model.objects;
using LeoLib.script;
using LeoLib.game.d2;
using LeoLib.game.model.asset.action;
using LeoLib.game.model.asset;

namespace LeoLib.game
{
    public class Window2D : GameWindow
    {
        private Shader shader;

        //private Sprite sprite = null;

        private Camera camera;

        private bool firstMove = true;

        private Vector2 lastPos;

        private Scene2D Scene { get; set; } = null;

        private EventContext eventContext { get; set; } = null;

        public Window2D(Scene2D scene, GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            Scene = scene;

            eventContext = new EventContext();
        }


        protected override void OnLoad()
        {
            GL.ClearColor(eventContext.Bg);

            GL.Enable(EnableCap.DepthTest);

            GL.Enable(EnableCap.Blend);
            //GL.BlendFunc((BlendingFactor)BlendingFactorSrc.SrcAlpha, (BlendingFactor)BlendingFactorDest.OneMinusSrcAlpha);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            CursorGrabbed = true;

            shader = new Shader(Constant.SHADER_VERT, Constant.SHADER_FRAG);
           
            camera = new Camera(Vector3.UnitZ * 5.0f, Size.X / (float) Size.Y);

            Scene.Construct();

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs eventArgs)
        {
            float deltaTime = (float) eventArgs.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            eventContext.DeltaTime = deltaTime;

            Scene.Update(deltaTime);

            Scene.Check(eventContext);

            Scene.Render(camera, shader);

            SwapBuffers();

            base.OnRenderFrame(eventArgs);
        }

        protected override void OnUpdateFrame(FrameEventArgs eventArgs)
        {
            if (IsFocused) 
            {
                eventContext.Input = KeyboardState;

                if (eventContext.Input.IsKeyDown(Keys.Escape))
                {
                    Close();
                }
            }

            base.OnUpdateFrame(eventArgs);
        }

        protected void xOnUpdateFrame(FrameEventArgs e)
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

            Scene.OnUnLoad();

            GL.DeleteProgram(shader.handle);
            //GL.DeleteTexture(texture1.handle);
            //GL.DeleteTexture(texture2.handle);

            base.OnUnload();
        }
    }
}
